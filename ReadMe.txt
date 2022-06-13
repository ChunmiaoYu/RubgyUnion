1.Solution Name: RugbyUnion1
2.Structure:
	Database under folder: App_Data
	2 controllers under folder: Controllers
	7 repositories under folder: Data
	3 Dto files under folder: DataTransferObjects
	ServiceExtension file under folder: Extensions
	2 models under folder: Models
	Mapping file under project， called "MappingProfile.cs"
	main function: Program.cs
3.Functions:
	add a new player to the system, in PlayerController.cs:  CreatePlayer    // POST api/Player
	add a new team to the system, in TeamController.cs: CreateTeam           // POST api/Team
	sign a player to a team, in PlayerController.cs: SignPlayer              // PUT api/Player/5
	display a list of all the players, in PlayerController.cs: GetAll		// GET: api/Player
	a list of all the teams, in TeamController.cs: GetAll				// GET: api/Team
	allow the user to select a player and display the team that player is signed in, in PlayerController.cs: SignPlayer	// PUT api/Player/5
	allow the user to select a team and display all of the players signed with it, in TeamController.cs: GetById			// GET api/Team/5
4.Additional Functions:
	Search by age and appropriate display information of all the players who are that age, in PlayerController.cs: GetByAge	// GET api/Player/Age/11
	Search by coach display information of all the players whose coach is that coach, in PlayerController.cs: GetByCoach	// GET api/Player/Coach/Coach1
	Unit tests: RugbyUnion.Test  (not finished).
	Correct http response codes


