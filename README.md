# input-mask-xamarin-ios
User input masking library ported to Xamarin.IOS

Original version: https://github.com/RedMadRobot/input-mask-ios

![Preview](https://raw.githubusercontent.com/RedMadRobot/input-mask-ios/assets/Assets/phone_input_cropped.gif "Preview")

## Description
The library allows to format user input on the fly according to the provided mask and to extract valueable characters.  

Masks consist of blocks of symbols, which may include:

* `[]` — a block for valueable symbols written by user. 

Square brackets block may contain any number of special symbols:

1. `0` — mandatory digit. For instance, `[000]` mask will allow user to enter three numbers: `123`.
2. `9` — optional digit . For instance, `[00099]` mask will allow user to enter from three to five numbers.
3. `А` — mandatory letter. `[AAA]` mask will allow user to enter three letters: `abc`.
4. `а` — optional letter. `[АААааа]` mask will allow to enter from three to six letters.
5. `_` — mandatory symbol (digit or letter).
6. `-` — optional symbol (digit or letter).

Other symbols inside square brackets will cause a mask initialization error.

Blocks may contain mixed types of symbols; such that, `[000AA]` will end up being divided in two groups: `[000][AA]` (this happens automatically).

Blocks must not contain nested brackets. `[[00]000]` format will cause a mask initialization error.

Symbols outside the square brackets will take a place in the output.
For instance, `+7 ([000]) [000]-[0000]` mask will format the input field to the form of `+7 (123) 456-7890`. 

* `{}` — a block for valueable yet fixed symbols, which could not be altered by the user.

Symbols within the square and curly brackets form an extracted value (valueable characters).
In other words, `[00]-[00]` and `[00]{-}[00]` will format the input to the same form of `12-34`, 
but in the first case the value, extracted by the library, will be equal to `1234`, and in the second case it will result in `12-34`. 

Mask format examples:

1. [00000000000]
2. {401}-[000]-[00]-[00]
3. [000999999]
4. {818}-[000]-[00]-[00]
5. [A][-----------------------------------------------------]
6. [A][_______________________________________________________________]
7. 8 [0000000000] 
8. 8([000])[000]-[00]-[00]
9. [0000]{-}[00]
10. +1 ([000]) [000] [00] [00]

# License

The library is distributed under the MIT [LICENSE](https://opensource.org/licenses/MIT).
