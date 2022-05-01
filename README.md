# MadLibs
This is a MadLibs game written in C#<br>
It opens and reads from several text files.<br>
One of these files (speechsymbols.txt) stores the different symbols used for the MadLibs program.<br>
It stores everything from a noun to adjective and other types of words in between.<br>
This program stores these different symbols in an array.  This array is then applied to the other text files,<br>
the actual MadLibs themselves.<br>  

One of the challenges I had in writing this program was the directory to use.  I decided to place the different (.txt) files<br>
in the C:\Temp\MadLibs\ directory.  The text files need to be in this directory for the program to work successfully.<br>
<br>
Another challenge I had in writing this program was when it came to reading from a symbol in the MadLib text files.<br>
When the file would contain more than one symbol, it wouldn't pick it up when reading the program.<br>
I did two primary things to solve this.<br>
    1.)  I wrote a nested for loop to search for the symbols in the text file.<br>
    2.)  And I also added a different symbol, so that it would be picked up when reading the file.<br>
         (ex.  If the file had two nouns on the same line, I added another symbol for the second use of the noun in the same line.)<br>
