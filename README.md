# LFWCSB
Live Football World Cup Score Board
is simple class library project that provide some service for getting and updating information
about all the ongoing matches and their scores.
 
Football World Cup Scoreboard supports the following operations:
1. Start a new match with score 0 : 0.
2. Update score. (Updates home team score and away team score)
3. Finish match. (This removes a football match from the scoreboard but not from the data source)
4. Get a summary of matches in progress ordered by their total score.

Solution includes class libriary project with Service, Repository and DataSource
and Unit Tests project for testing Service's methods. On the DataSource layer 
implemented all CRUD operations, but on Repository and Service layers 
did not implemente "Delete" operation (according task's requirements).
 