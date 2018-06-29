# MusicsOnlinePlayer
Free musics player made in c#. 
Any help is welcome, i can also speack french if you want.
So the project is made arround 3 mains subjects : The Server, the client and the utility file ( a common library ).
Here is a simple summary and how it work :

# Server
At launch the server will do an indexation in the directory c:/AllMusics or create this directory if it doesn't exist.
The indexation consists in two parts :
 - Recognize all musics files and put in a list of "Music" with only the path of the file. With that we can know who created the musics and in which album it is.
 - Create or complete a xml file wich contains all the "MetaData" of every musics. For exemple : Who liked the musics.
 
