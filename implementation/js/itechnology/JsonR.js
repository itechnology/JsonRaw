; (function (window, undefined) {
    var JSONR = {
        parse: function(keys, values) {
            return JSONR.keyValuesToObject(keys, values);
        },
        stringyfy: function() {
          // not implemented
        },
        
		// Merges a collection of keys and a collection of values back into a standard JSON object
		// This was kindly contributed by Peter Olson
        // http://stackoverflow.com/questions/13831541/recursively-recombining-split-key-values-pairs	
        keyValuesToObject:function (keys, values) {
	
            var obj = [];
            
            for (var i = 0, l = values.length; i < l; i++) {
                var value = values[i];
                
                obj.push({});                
                for (var j = 0, m = value.length; j < m; j++) {
                    var key = keys[j];
                    
                    if (typeof key === "object") {
                        // change to for (i) ?
                        for (var k in key) {
                            obj[i][k] = JSONR.keyValuesToObject(key[k], value[j]);
                        }
                    }
                    else {
                        obj[i][key] = value[j];
                    }
                }
            }
            
            return obj;
        }
    };


    window.JSONR = JSONR;
})(window);