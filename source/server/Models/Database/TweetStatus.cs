//
// Copyright (c) 2022 karamem0
//
// This software is released under the MIT License.
//
// https://github.com/karamem0/preddy/blob/main/LICENSE
//

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Karamem0.Preddy.Models.Database
{

    [Index(nameof(StatusId), IsUnique = true)]
    [Index(nameof(TweetedAt), IsUnique = true)]
    [Table(nameof(TweetStatus))]
    public class TweetStatus
    {

        public TweetStatus()
        {
        }

        [Key()]
        public Guid Id { get; set; }

        [Column(TypeName = "decimal(20, 0)")]
        public ulong StatusId { get; set; }

        [Column(TypeName = "decimal(20, 0)")]
        public ulong UserId { get; set; }

        [Required()]
        [StringLength(80)]
        public string? UserName { get; set; }

        [Required()]
        [StringLength(40)]
        public string? ScreenName { get; set; }

        [StringLength(1024)]
        public string? ProfileImageUrl { get; set; }

        [StringLength(1024)]
        public string? MediaUrl { get; set; }

        [StringLength(1024)]
        public string? Text { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime TweetedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime UpdatedAt { get; set; }

    }

}
