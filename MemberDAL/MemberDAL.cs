using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jolly_pirate {
    class MemberDAL {
        public List<Member> memberList;
        private static string fileName = "members.json";

        // Contrsuctor to make oroginalfile read at start.
        public MemberDAL () 
        {
            string originalData = File.ReadAllText (fileName);

            if (originalData == "") 
            {
                this.memberList = new List<Member> ();
            } 
            else 
            {
                this.memberList = JsonConvert.DeserializeObject<List<Member>> (originalData);
            }

        }

        public void SaveToFile () 
        {
            using (StreamWriter file = File.CreateText (fileName)) 
            {
                string json = JsonConvert.SerializeObject (this.memberList, Formatting.Indented);
                file.Write (json);
            }
        }

        public void AddMember (Member member)
        {
            this.memberList.Add(member);
        }

        // EJ TESTAD!
        public void DeleteMember(int memberID)
        {
            var item = memberList.SingleOrDefault(x => x.id == memberID);
            if (item != null)
            memberList.Remove(item);
            // SELECT MEMBER WHERE ID : get index 
        }
        public void CompactListOfMembers () 
        {
            foreach (var item in this.memberList) 
            {

                Console.WriteLine ($"Name: {item.fullName}, Social security number: {item.SSN}, memberID: {item.id}, Number of boats: {item.boatList.Count}");
            }
        }
        public void VerboseListOfMembers () 
        {
            string boats = "";

            foreach (var member in this.memberList) 
            {
                foreach(var boat in member.boatList) 
                {
                    boats += boat;
                
                }
                Console.WriteLine ($"Name: {member.fullName}, Social security number: {member.SSN}, MemberID: {member.id}, Boat list: {boats}");
            }
        }
    }
}