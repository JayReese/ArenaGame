using UnityEngine;
using System.Collections;
using System.Xml;
using System;

public static class DatabaseManager
{
    static string BaseDataPath = Application.dataPath;
	
    // The primary 
    public static object ReturnQueriedData(DataQueryType type, string objectName, string queryAttr, string queryCateg)
    {
        return GetXMLData(type, objectName, queryAttr, queryCateg);
    }

    // Gets the queried data from the XML file.
    static object GetXMLData(DataQueryType type, string objectName, string queryAttribute, string queryCategory)
    {
        // Returns the file name of the XML file.
        string returnedFile = ReturnXMLFile(type);

        // Checks if the returned file name is empty. 
        // If NOT, continue down the line.
        if (returnedFile != string.Empty)
        {
            // Creates a new XmlReader instance to read through everything necessary.
            XmlReader reader = XmlReader.Create(BaseDataPath + "/" + returnedFile);

            // While we're still reading the XML file, continue.
            while (reader.Read())
            {
                // Reads the XML node, and determines if it's an element and it isn't the root.
                if(reader.NodeType == XmlNodeType.Element && ((type == DataQueryType.Abilities && reader.LocalName != "AbilityList") || (type == DataQueryType.Weapons && reader.LocalName != "WeaponList")))
                {
                    while (reader.GetAttribute("Name") != objectName && ((type == DataQueryType.Abilities && reader.ReadToNextSibling("Ability")) || (type == DataQueryType.Weapons && reader.ReadToNextSibling("Weapon"))))
                        continue;
                
                    // If it's anything else but the name, you must also have the category filled out.
                    if(queryCategory != string.Empty)
                    {
                        // Reads to the next descendant.
                        if(reader.ReadToDescendant(queryCategory))
                            return RetrieveDataFromQueriesElement(reader, queryAttribute); // Returns the data retrieved from the search.
                    }      
                }   
            }
        }

        return null;
    }

    // Retrieves everything queried for based on the ability's name.
    private static object RetrieveDataFromQueriesElement(XmlReader reader, string queryAttribute)
    {
        return reader.GetAttribute(queryAttribute);
    }

    // Returns the name of the XML file based on the data query type.
    private static string ReturnXMLFile(DataQueryType type)
    {
        // A switch statement based on the data query type of the abilities shown.
        switch (type)
        {
            case DataQueryType.Abilities:
                return "Abilities.xml";
            case DataQueryType.Weapons:
                return "Weapons.xml";
        }

        // This returns an empty string. If this somehow happens, you've made a grievous error.
        return string.Empty;
    }
}
