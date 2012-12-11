function mergeKeyValues(jsonR) {
    /// <summary>Merges a custom json array into a name/value json collection</summary>

    // Empty or missign object
    if (typeof (jsonR) === 'undefined' || jsonR == null) {
        return null;
    }

    // Nothing to merge here, return original object
    if (typeof (jsonR.Values) === 'undefined' || typeof (jsonR.Values) == null || typeof (jsonR.Keys) === 'undefined' || typeof (jsonR.Keys) == null) {
        return jsonR;
    }

    var out = [];

    // Now merge all the key/values
    for (var vi = 0, vl = jsonR.Values.length; vi < vl; vi++) {
        out[vi] = {};

        for (var ki = 0, kl = jsonR.Keys.length; ki < kl; ki++) {
            out[vi][jsonR.Keys[ki]] = jsonR.Values[vi][ki];
        }
    }

    return out;
}