##Lightweight JSON protocol proposal: JsonR

Simplified and lightweight protocol where key/value pairs are either seperated and later recombined, or where keys can be completely ommited and later added via implicit casting or via a hint to the objetcs real type.

####Size gains become linear with collections

###Classic JSON

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


  			
###JsonR Object (Implicit)
          
    var object = [
                    "Jason",
                    31,
                    ["123.jpg", "222.jpg"],
                    [["Bob", "Hope"], ["Foo", "Bar"]]
    ]; 
					
								
###JsonR Object (With Hint)        
          
    var object = {
                Type  : "User",
                Values:[
                            "Jason",
                            31,
                            ["123.jpg", "222.jpg"],
                            [["Bob", "Hope"], ["Foo", "Bar"]]
                ]
    }; 
					
					
###JsonR Object (Without Hint)         
          
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
					
###JsonR Object (Full Signature)

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