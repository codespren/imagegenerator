# Image generator

Generates all 1000 * 1000 pixel images. Images are created in a random order and there may be duplicates but eventually
all possible images are created.

The program has some interesting features, for example among the images generated are the following images:

- Image of this program's source code.
- Photo of the murder of Julius Caesar.
- Image of next week's lottery numbers.
- Every frame of every movie ever filmed in the past and in the future.
- Photo of you reading this file.
- Photo of the alien lifeform that is living closest to us.

## Usage:

Build:
`dotnet build`

Create 10 test images:
`dotnet run test`

Create all images (make sure you have enough disk space):
`dotnet run all`

The program will create a folder named '0' and create first 18446744073709551615 images in to that folder.
After that, it will create a second folder named '1' and create next 18446744073709551615 images to that folder and so on.
When there are 18446744073709551616 folders created with 18446744073709551615 images in each it will create next images
again to the folder named '0'. Because of that it is necessary from time to time to make a backup of older folders
because images in them will be overwritten. However, if the computer creates for example 10 images in a second then
the first override will not happen until 1079028307080601418780064432028 years has passed so there's no need for hurry.
