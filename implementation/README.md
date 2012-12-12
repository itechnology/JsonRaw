####If you build a client or server-side implementation that supports the JsonR Spec, please submit it to the project

1. Clone the project
2. Add your implementation
3. Issue a pull request
4. Smile !


### Sample Input C<notextile>#</notextile>

	// Mockup class
	public class User {
		public string Name { get; set; }    
		public int Age     { get; set; }
		public List<string> Photos  { get; set; }
		public List<Friend> Friends { get; set; }       
	}
	// Mockup class
	public class Friend {
		public string FirstName { get; set; }
		public string LastName  { get; set; }
	}

	// Initialize objects
	var userList = new List<User>();
	userList.Add(new User() { 
								Name   = "Robert",
								Age     = 32,
								Photos  = new List<string> { "1.jpg", "2.jpg" },
								Friends = new List<Friend>() {
																new Friend() { FirstName = "Bob", LastName = "Hope"},
																new Friend() { FirstName = "Mr" , LastName = "T"}
								}
				}
	);  
	userList.Add(new User() { 
								Name   = "Jane",
								Age     = 21,
								Photos  = new List<string> { "4.jpg", "5.jpg" },
								Friends = new List<Friend>() {
																new Friend() { FirstName = "Foo"  , LastName = "Bar"},
																new Friend() { FirstName = "Lady" , LastName = "Gaga"}
								}
				}
	);

### Sample Pre-Result C<notextile>#</notextile>
    var keys   = new object[] {"Name", "Age", "Photos", new { Friends = new [] {"FirstName", "LastName"}}};
    var values = new [] { new object[] {"Robert", 32, new [] {"1.jpg", "2.jpg"}, new [] {new [] {"Bob", "Hope"}, new [] {"Mr", "T"}}}, new object[] {"Jane", 21, new [] {"4.jpg", "5.jpg"}, new [] {new [] {"Foo", "Bar"}, new [] {"Lady", "Gaga"}}}}


### Expected Final Result (then to be returned to client as JSON string)
	{
	   Keys  : ["Name","Age","Photos",{"Friends":["FirstName","LastName"]}],
	   Values: [["Robert",32,["1.jpg","2.jpg"],[["Bob","Hope"],["Mr","T"]]],["Jane",21,["4.jpg","5.jpg"],[["Foo","Bar"],["Lady","Gaga"]]]]
	}



### Expected Result JS (once client applies recombination)
	var users = [
					{ 
						"Name"    : "Robert",
						"Age"     : 32,
						"Photos"  : [ "1.jpg", "2.jpg" ],
						"Friends" : [
										{ "FirstName" : "Bob", "LastName" : "Hope" },
										{ "FirstName" : "Mr" , "LastName" : "T"    }
						]
					},
					{ 
						"Name"    : "Jane",
						"Age"     : 21,
						"Photos"  : [ "4.jpg", "5.jpg" ],
						"Friends" : [
										{ "FirstName" : "Foo"  , "LastName" : "Bar"  },
										{ "FirstName" : "Lady" , "LastName" : "Gaga" }
						]
					}
				];