# MusicsOnlinePlayer
Free musics player made in c#. 
Any help is welcome, i can also speack french if you want.
So the project is made arround 3 mains subjects : The Server, the client and the utility file ( a common library ).
Here is a simple summary and how it work :

### Server
At launch the server will do an indexation in the directory c:/AllMusics or create this directory if it doesn't exist.
The indexation consists in two parts :
 - Recognize all musics files and put in a list of *Music* with only the path of the file. With that we can know who created the musics and in which album it is. The music name must be the same as this `Something - Music Name` and the Musics "tree" must be like this :
   - All Musics
     - Author Name
       - Album title
         - Music file
         
 * Create or complete a *xml* file wich contains all the "MetaData" of every *musics*. For exemple : Who liked the musics.
 
Now the server can receive socket connection in **async** mode. If a client client is connected the server will wait for him to login and receive a *login* message.

#### Login
The login is pretty simple and is based on hashable function ( in this case **SHA256** ). The client will first send his user class in a login class. The user class should contain his username and also his **SHA256** hash made of the Username and the Password. With that the server can identify who is try to log in by searching in the xml *user.xml*.

### Requests

For the moment there is multiple type of request that the client can make :
 - `RequestSearch` is where the client can ask to the server to make a search. The client must specify the search text and what he want to search ( Music, Album, Author ). The server will respond with a `RequestSearchAnswer`
 - `RequestMusic` allows the user to ask for a music filebinnaries. The server will answer with `RequestMusicAnswer` wich contains the music with the binnaries.
 
### Client
Once the 
