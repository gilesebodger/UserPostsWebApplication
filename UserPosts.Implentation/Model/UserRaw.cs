using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace UserPosts.Implentation.Model
{
    [DataContract]
    public class UserRaw
    {
        [DataMember(Name ="id")]
        public int Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "username")]
        public string UserName { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }



        [DataMember(Name = "address")]
        public Address Address { get; set; }



        [DataMember(Name = "phone")]
        public string Phone { get; set; }

        [DataMember(Name = "website")]
        public string Website { get; set; }



        [DataMember(Name = "company")]
        public Company Company { get; set; }
    }


    [DataContract]
    public class Address
    {
        [DataMember(Name = "street")]
        public string Street { get; set; }

        [DataMember(Name = "suite")]
        public string Suite { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "zipcode")]
        public string Zipcode { get; set; }


        [DataMember(Name = "geo")]
        public Geo Geo { get; set; }    

    }


    [DataContract]
    public class Geo
    {
        [DataMember(Name = "lat")]
        public double Lat { get; set; }

        [DataMember(Name = "lng")]
        public double Lng { get; set; }
    }


    [DataContract]
    public class Company
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "catchPhrase")]
        public string CatchPhrase { get; set; }

        [DataMember(Name = "bs")]
        public string BS { get; set; }
    }
}


// modelled from the json
/*
 * "id": 4,
  "name": "Patricia Lebsack",
  "username": "Karianne",
  "email": "Julianne.OConner@kory.org",
  "address": {
    "street": "Hoeger Mall",
    "suite": "Apt. 692",
    "city": "South Elvis",
    "zipcode": "53919-4257",
    "geo": {
      "lat": "29.4572",
      "lng": "-164.2990"
    }
  },
  "phone": "493-170-9623 x156",
  "website": "kale.biz",
  "company": {
    "name": "Robel-Corkery",
    "catchPhrase": "Multi-tiered zero tolerance productivity",
    "bs": "transition cutting-edge web services"
  }
 */