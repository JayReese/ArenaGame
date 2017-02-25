using UnityEngine;
using System.Collections;
using System.Xml;
using System;

public static class DatabaseManager
{
    
    static string BaseDataPath = Application.dataPath + "/Resources";
	
    public static object ReturnQueriedData(DataQueryType type)
    {
        GetXMLData(type);
        return 0;
    }

    static object GetXMLData(DataQueryType type)
    {
        
        string returnedFile = ReturnXMLFile(type);

        if (returnedFile != string.Empty)
        {
            return "yay";
        }

        return null;
    }

    // Returns the name of the XML file based on the data query type.
    private static string ReturnXMLFile(DataQueryType type)
    {
        switch (type)
        {
            case DataQueryType.Abilities:
                return "Abilities.xml";
        }

        return string.Empty;
    }
}
