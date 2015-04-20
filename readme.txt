The functionalities implemented in our web application are

Registering New User

A new user can able to register in our application by providing unique userid and email.
This functionality is achieved with AddUser button present in login screen

Log in

User can log in to the application by providing his userid and password.
Every log in activity is recorded in our database.
After successful login he will be redirected to Dashboard Page.

Dashboard 

Search option is provided for user to search videos similar to the youtube search.
User enters search word and click search icon to get relevant videos.
This is achieved by using YouTube V3 API in our application.
After getting results, they are displayed in table. Upon clicking of Thumbnail you will be redirected to youtube and the corresponding 
video will be played.

Recent Searches

Every Search made by user is recorded in our database. If search increases more than 20, previous items will be updated with 
new searched items.
If you click on the search history in menu option, popup will be displayed containing search words used by user.

Viewed Videos

Every Video viewed by user is recorded in our database. If views increases more than 20, previous items will be updated with 
new viewed items.
If you click on the Viewed Videos in menu option, popup will be displayed containing Videos viewed by user.
