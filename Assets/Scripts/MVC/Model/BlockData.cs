using System;
using Newtonsoft.Json;

[Serializable]
public class BlockData
{
    [JsonProperty]
    public int Id;
    [JsonProperty]
    public string Subject;
    [JsonProperty]
    public string Grade;
    [JsonProperty]
    public Mastery Mastery;
    [JsonProperty]
    public string Domainid;
    [JsonProperty]
    public string Domain;
    [JsonProperty]
    public string Cluster;
    [JsonProperty]
    public string Standardid;
    [JsonProperty]
    public string Standarddescription;

    public BlockData (
        int Id,
        string Subject,
        string Grade,
        Mastery Mastery,
        string Domainid,
        string Domain,
        string Cluster,
        string Standardid,
        string Standarddescription
    )
    {
        this.Id = Id;
        this.Subject = Subject;
        this.Grade = Grade;
        this.Mastery = Mastery;
        this.Domainid = Domainid;
        this.Domain = Domain;
        this.Cluster = Cluster;
        this.Standardid = Standardid;
        this.Standarddescription = Standarddescription;
    }
}