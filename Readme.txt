Description

This app has 3 pages. 

Main Page

The main page displays the images. The content of the Image is changed based on the time interval set by users. 
An ActivityIndicator displays when image is being loaded.
There is a count down display label which displays the time remaining to show the next image. It resets when a new is image displayed.
The user gets to directly input the interval value setting through an Entry or adjust a slider or a stepper for setting the time interval. 
(Entry, Slider and Stepper are synchronized with each other -through data binding).

On/Off Switch

Switch is used to turn on or off the change of the images. 

The image list page is the second page which is a modeless page and is navigated from the main page. 

The third page is the image detail page which allows users to edit the image source and notes of a photo.
The app must can be able to run on at least on two different platform emulators.

ViewModels

Each photo has the following four properties: source, date taken, title and detail. 
A command interface allows users to move the sequence of the photo and edit the photo information through databinding. 
The data model can be preserved in a XML file.  

 
Image List Page (Modeless)

The image list page contains a ListView which binds  ViewModel to list out all the images with the time taken and title. 
Allows user to edit, add, or remove an image in the list.


