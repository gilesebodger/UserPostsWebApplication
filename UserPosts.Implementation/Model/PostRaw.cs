﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace UserPosts.Implementation.Model
{
    [DataContract]
    public class PostRaw
    {
        [DataMember(Name ="userid")]
        public int UserId { get; set; }

        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }
    }
}
