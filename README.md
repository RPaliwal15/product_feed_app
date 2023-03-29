Installation steps :
1. Set connection string in appsetting.json
2. Db creation run following command 
   
	CREATE TABLE capterra (
    tags varchar(255),
    name varchar(255),
    twitter varchar(255)
	);
	
	CREATE TABLE softwareadvice (
    categories varchar(1000),
    twitter varchar(255),
    title varchar(255)
	);
	
3. Run solution in visual studio and than set command line argument (for command line  we have to build project and use Dotnet run command with argument)
4. Argument - import softwareadvice path-of-file     (replace softwareadvice with capterra)


Future Improvements
1. Dependency injection can be use.
2. Use Keyvalut in place of appsetting.json for connection string.
3. DB connector code improvement. 
4. More test cases 
