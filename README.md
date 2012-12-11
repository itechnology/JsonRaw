##Lightweight JSON protocol proposal: JsonR

Simplified and lightweight protocol where key/value pairs are either seperated and later recombined, or where keys can be completely ommited and later added via implicit casting or via a hint to the objetcs real type.

####Gains are in the order of +102% to -1% per/object, and become more obvious in collections

###JSON (classic) 156 chars

    var object = {
                "Pseudo" : "Jason",
                "Age"    : 31,
                "Photos" : ["123.jpg", "222.jpg"]
                "Friends": [ 
                               {
                                   "FirstName": "Bob",
                                   "LastName" : "Hope"
                                },
                                {
                                    "FirstName": "Foo",
                                    "LastName" : "Bar"
                                }
                ] 
    };


  			
###JsonR (Implicit) 77 chars
          
    var object = [
                    "Jason",
                    31,
                    ["123.jpg", "222.jpg"],
                    [["Bob", "Hope"], ["Foo", "Bar"]]
    ]; 
					
								
###JsonR (With Hint) 89 chars
          
    var object = {
                Type  : "User",
                Values:[
                            "Jason",
                            31,
                            ["123.jpg", "222.jpg"],
                            [["Bob", "Hope"], ["Foo", "Bar"]]
                ]
    }; 
					
					
###JsonR (Without Hint) 153 chars
          
    var object = {
                Keys:[
                           "Pseudo",
                           "Age",
                           "Photos",
                           "Friends": ["FirstName", "LastName"]
                ],
                Values:[
                            "Jason",
                            31,
                            ["123.jpg", "222.jpg"],
                            [["Bob", "Hope"], ["Foo", "Bar"]]
		]
    };  
					
###JsonR (Full Signature) 164 chars

    var object = {
                Type: "User",
                Keys:[
                          "Pseudo",
                          "Age",
                          "Photos",
                          "Friends": ["FirstName", "LastName"]
                 ],
                 Values:[
                            "Jason",
                            31,
                            ["123.jpg", "222.jpg"],
                            [["Bob", "Hope"], ["Foo", "Bar"]]
	         ]
    };				