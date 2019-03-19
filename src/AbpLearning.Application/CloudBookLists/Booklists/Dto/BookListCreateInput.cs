﻿namespace AbpLearning.Application.CloudBookLists.BookLists.Dto
{
    using System.ComponentModel.DataAnnotations;
    using AbpLearning.Application.Base;

    public class BookListCreateInput : INullIdEntityDto
    {
        /// <summary>
        /// 书单名
        /// </summary>
        [Required]
        [MaxLength(32)]
        public string Name { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        [MaxLength(128)]
        public string Intro { get; set; }
    }
}
