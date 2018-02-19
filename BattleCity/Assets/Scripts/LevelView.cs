using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class LevelView : MonoBehaviour 
{
    Block[][] gridLayout = new Block[13][];

    Level levelXML = new Level();

    IEnumerator Start()
    {
        yield return null;
        for(int row = 0; row < gridLayout.Length; ++row)
        {
            gridLayout[row] = new Block[13];
        }

        InitLevel();
    }

	void InitLevel()
    {
		for(int row = 0; row < gridLayout.Length; ++row)
        {
            for (int column = 0; column < gridLayout[row].Length; ++column)
            {
                var go = Instantiate(GameManager.Instance.GenericResources.Blocks[0]);
                go.transform.position = new Vector3(column, row, 0);
                gridLayout[row][column] = go.GetComponent<Block>();
            }
        }

        SaveLevelToXML();
    }

    void SaveLevelToXML()
    {   
        for(int row = 0; row < gridLayout.Length; ++row)
        {           
            Row rowInfo = new Row();

            for(int column = 0; column < gridLayout[row].Length; ++column)
            {
                var columnInfo = new Column();
                string blockName = GameManager.Instance.GenericResources.Blocks[0].ToString();
                columnInfo.Block = blockName;
                columnInfo.ColumnID = column;
                rowInfo.Columns.Add(columnInfo);
                Debug.Log("Adding column ID: " + column + " With name: " + blockName);
                //  columnInfo.
            }

            levelXML.Rows.Add(rowInfo);
        }

        levelXML.Save(Path.Combine(Application.dataPath, "level.xml"));
    }

    void LoadLevelFromXML(string levelName)
    {
/*
        XmlDocument doc = new XmlDocument();
        doc.Load(UnityEngine.Application.dataPath + "/" + levelName + ".xml");
        XmlNode root = doc.FirstChild;
        for(int i = 0; i < root.SelectNodes("descendant::*").Count; i++)
        {
            if(root.SelectNodes("descendant::*")[i].Name.ToString().ToLower().Contains("enddate"))
            {
                string tempString = root.SelectNodes("descendant::*")[i].InnerText;
                tempString = tempString.Substring(1, 8);
                string newDate = tempString.Substring(2, 2) + "/";
                newDate += tempString.Substring(0, 2) + "/";
                newDate += tempString.Substring(6);
                DateTime licDate = DateTime.Parse(newDate);

                if(DateTime.Today.Date > licDate.Date)
                {
                    //MessageBox.Show("Your lic is expired");
                }
                else {
                    //UnityEngine.Debug.Log("Your lic is running");
                }
            }

            if(root.SelectNodes("descendant::*")[i].Name.ToString().ToLower().Contains("coursepackname"))
            {
                coursePackName.Add(root.SelectNodes("descendant::*")[i].InnerXml);
                //              print (root.SelectNodes ("descendant::*") [i].InnerXml);
            }
        }*/
    }     
}
