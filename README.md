# Small repro of my problems with measuring text size with ImageSharp

The image result.png is the output after trying to center the letters. As one can see
it isn't centered vertically.

![result.png](https://github.com/karl-sjogren/imagesharp-textmeasure-problem/blob/master/result.png?raw=true)

The program outputs the following to the console after measuring the text.

Measured size: 400.1953, 303.6621, Text: KS

A quick crop of the resulting image says the text is just about 365x224
which accounts for it not being properly centered (since the height seems
to be way to high).

![result-cropped.png](https://github.com/karl-sjogren/imagesharp-textmeasure-problem/blob/master/result-cropped.png?raw=true)
