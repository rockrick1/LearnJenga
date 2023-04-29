using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;

public class StackLoaderModel : IDisposable
{
    const string DATA_URL = "https://ga1vqcu3o1.execute-api.us-east-1.amazonaws.com/Assessment/stack";
    
    public Dictionary<string, List<BlockData>> Stacks { get; private set; } = new();

    List<BlockData> blocks;

    public StackLoaderModel ()
    {
    }

    public void Initialize ()
    {
        LoadData();
    }

    void LoadData ()
    {
        HttpWebRequest request = (HttpWebRequest) WebRequest.Create(DATA_URL);
        HttpWebResponse response = (HttpWebResponse) request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        blocks = JsonConvert.DeserializeObject<List<BlockData>>(jsonResponse);

        foreach (BlockData block in blocks)
        {
            if (!Stacks.TryGetValue(block.Grade, out List<BlockData> gradeStack))
            {
                gradeStack = new List<BlockData>();
                Stacks.Add(block.Grade, gradeStack);
            }
            gradeStack.Add(block);
        }

        Dictionary<string, List<BlockData>> temp = new();
        foreach (string grade in Stacks.Keys)
        {
            List<BlockData> stack = Stacks[grade];
            //TODO check sorting here
            temp[grade] = stack.OrderBy(x => x.Domain)
                .ThenBy(x => x.Cluster)
                .ThenBy(x => x.Standardid)
                .ToList();
        }

        Stacks = temp;
    }

    void AddListeners ()
    {
    }

    void RemoveListeners ()
    {
    }

    public void Dispose ()
    {
        RemoveListeners();
    }
}