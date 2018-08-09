![Logo](https://github.com/MalauD/MusicsOnlinePlayer/blob/master/Image/MusicicodLarge.png)

[![CodeFactor](https://www.codefactor.io/repository/github/malaud/musicsonlineplayer/badge/master)](https://www.codefactor.io/repository/github/malaud/musicsonlineplayer/overview/master)

# MusicsOnlinePlayer
Free musics player made in c#. 
Any help is welcome, i can also speack french if you want.
Please consider that my code isn't perfect (and my english) so to enchance it you can make a pull request.

## Introduction
the project is made arround 3 mains subjects : The Server, the client and the utility file ( a common library ).
Here is a simple summary and how it works :

## Server
At launch the server will do an indexation in the directory `c:/AllMusics` or creates this directory if it doesn't exist.
The indexation consists of two parts :
 - Indentify all musics files and put in a list of *Music* with only the path of the file. With that we can know the artist and the album of the music without having the audio track. You can put `-ignore` at the end of the album directory to not index it in the server. The music title is pick with the `Taglib` library. The Musics "tree" must be like this to work correctly and recognize all informations:
![Image of the tree](https://github.com/MalauD/MusicsOnlinePlayer/blob/master/Image/GitHubImage.PNG)
         
 * Creates or completes a *xml* file wich contains all the "MetaData" of every *musics*. For exemple : Who liked the musics.
 
Now the server can receive socket connection in **async** mode. If a client client is connected the server will wait for him to login and receive a *login* message.

### Login
The login is pretty simple and is based on hashable function ( in this case **SHA256** ). The client will first send his user class in a login class. The user class should contain his username and also his **SHA256** hash made of the Username and the Password. With that the server can identify who is trying to log in by searching in the xml *user.xml* without knowing the password.

### Requests
For the moment there are multiples types of request that the client can make :
 - `RequestSearch` is where the client can ask to the server to make a search. The client must specify the search text and what he want to search ( Music, Album, Author ). The server will respond with a `RequestSearchAnswer`
 - `RequestMusic` allows the user to ask for a music filebinnaries. The server will answer with `RequestMusicAnswer` wich contains the music with the binnaries.
 
### Server command
There is multiple server command that can help you quite a lot.The command always start with **-**. Here is the list :
 - `-init` will create a directory for the music file if it doesn't exist.
 - `-index` will do an indexation again. See bellow for more detail.
 - `-users` will get all connected users and display his `Name`,`User ID` and his `Rank` you can add the `-all` parameters to get all registered users.
 - `-promote` will upgrade the grade of the specified users. Please use this syntax : `-promote -UID -NewRank`.
 - `-quit` will save all music information and stop the server application.
 

 
## Client
Once the client is connected with the form *Login.form*. He can access to differents tabs :
- `Search` to find and listen musics.
- `Account` to see his name and his user ID.

### Playing Music
To play music the client will first ask for the filebinnaries of the music to the server. Once the client receive it, he converts it to a file in the directory `c:/MusicsFiles`. The application will play it using `Wmplib.dll`. 

### Playlists
You can also create your own playlist and save it to your account through the server. With that you can share it to every user by making a search and check `Playlist` button.

### Hue
The client can handle the hue sytem and create a dico like ambiance. In the `Settings` menu you can connect to you own hue bridge to get an **API key** or if you already know it you can enter directly.

## How to install ?
First, download the client and / or server installer, open it and follow all the instruction. If you installed the client you just have to enter the ip of the server. If you launch the server for the first it will create a Musics directory in the `c://` folder. In this folder you can place all of your musics following the method shown just above and you are finally ready !
