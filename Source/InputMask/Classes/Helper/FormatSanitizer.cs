using System;
using System.Collections.Generic;
using System.Linq;
using InputMask.Classes.Model;

namespace InputMask.Classes.Helper
{
    public class FormatSanitizer
    {
        public string Sanitize(string formatString)
        {
            CheckOpenBraces(formatString);
            var blocks = DivideBlocksWithMixedCharacters(GetFormatBlocks(formatString));
            return string.Join("", SortFormatBlocks(blocks));
        }

        private void CheckOpenBraces(string content)
        {
            var squareBraceOpen = false;
            var curlyBraceOpen = false;

            foreach (var character in content)
            {
                if ('[' == character)
                {
                    if (squareBraceOpen)
                        throw new WrongFormatException();

                    squareBraceOpen = true;
                }
                if (']' == character)
                    squareBraceOpen = false;

                if ('{' == character)
                {
                    if (curlyBraceOpen)
                        throw new WrongFormatException();

                    curlyBraceOpen = true;
                }
                if ('}' == character)
                    curlyBraceOpen = false;
            }
        }

        private List<string> GetFormatBlocks(string content)
        {
            var blocks = new List<string>();
            var currentBlock = string.Empty;

            foreach (var character in content)
            {
                if ('[' == character || '{' == character)
                {
                    if (0 < currentBlock.Length)
                        blocks.Add(currentBlock);

                    currentBlock = string.Empty;
                }

                currentBlock += character;

                if (']' == character || '}' == character)
                {
                    blocks.Add(currentBlock);
                    currentBlock = string.Empty;
                }
            }

            if (!string.IsNullOrEmpty(currentBlock))
                blocks.Add(currentBlock);

            return blocks;
        }

        private List<string> DivideBlocksWithMixedCharacters(List<string> blocks)
        {
            var resultingBlocks = new List<string>();

            foreach (var block in blocks)
            {
                if (block.StartsWith("[", StringComparison.InvariantCulture))
                {
                    var blockBuffer = string.Empty;
                    foreach (var blockCharacter in block)
                    {
                        if (blockCharacter == '[')
                        {
                            blockBuffer += blockCharacter;
                            continue;
                        }
                        if (blockCharacter == ']')
                        {
                            blockBuffer += blockCharacter;
                            resultingBlocks.Add(blockBuffer);
                            break;
                        }

                        if (blockCharacter == '0' || blockCharacter == '9')
                        {
                            if (blockBuffer.Contains("A")
                                || blockBuffer.Contains("a")
                                || blockBuffer.Contains("-")
                                || blockBuffer.Contains("_"))
                            {
                                blockBuffer += "]";
                                resultingBlocks.Add(blockBuffer);
                                blockBuffer = "[" + blockCharacter;
                                continue;
                            }
                        }

                        if (blockCharacter == 'A' || blockCharacter == 'a')
                        {
                            if (blockBuffer.Contains("0")
                                || blockBuffer.Contains("9")
                                || blockBuffer.Contains("-")
                                || blockBuffer.Contains("_"))
                            {
                                blockBuffer += "]";
                                resultingBlocks.Add(blockBuffer);
                                blockBuffer = "[" + blockCharacter;
                                continue;
                            }
                        }

                        if (blockCharacter == '-' || blockCharacter == '_')
                        {
                            if (blockBuffer.Contains("0")
	                            || blockBuffer.Contains("9")
	                            || blockBuffer.Contains("A")
	                            || blockBuffer.Contains("a"))
                            {
                                blockBuffer += "]";
                                resultingBlocks.Add(blockBuffer);
                                blockBuffer = "[" + blockCharacter;
                                continue;
                            }
                        }

                        blockBuffer += blockCharacter;
                    }
                }
                else
                {
                    resultingBlocks.Add(block);
                }
            }
            return resultingBlocks;
        }

        public List<string> SortFormatBlocks(List<string> blocks)
        {
            var sortedBlocks = new List<string>();

            foreach (var block in blocks)
            {
                string sortedBlock;
				if (block.StartsWith("[", StringComparison.InvariantCulture))
                {
                    if (block.Contains("0") || block.Contains("9"))
                    {
                        sortedBlock = SortBlock(block);
                    }
                    else if (block.Contains("a") || block.Contains("A")){
                        sortedBlock = SortBlock(block);
                    }
                    else
                    {
                        sortedBlock = string.Format("[{0}]", new String(block
                                                 .Replace('[', char.MinValue)
                                                 .Replace(']', char.MinValue)
                                                 .Replace('_', 'A')
                                                 .Replace('-', 'a')
                                                 .OrderBy(c => c).ToArray()));

                        sortedBlock = sortedBlock.Replace('A', '_').Replace('a', '-');
                    }
                }
                else
                {
                    sortedBlock = block;
                }

                sortedBlocks.Add(sortedBlock);
            }

            return sortedBlocks;
        }

        private string SortBlock(string block)
        {
            return string.Format("[{0}]", new String(block.Where(c => c != '[' && c != ']').OrderBy(c => c).ToArray()));
        }
    }
}
