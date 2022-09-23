﻿using DevBlog.DataAccess.Interfaces;
using DevBlog.Dtos.Tags;
using DevBlog.Mappers;
using DevBlog.Services.Interfaces;
using DevBlog.Shared.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevBlog.Services.Implementations
{
    public class TagService : ITagService
    {
        private ITagRepository _tagRepository;
        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public void CreateTag(CreateTagDto createTagDto)
        {
            var tagExists = _tagRepository.GetTagByValue(createTagDto.Value);
            if (tagExists != null)
            {
                throw new TagDataException("The tag already exists!");
            }
            _tagRepository.Add(createTagDto.ToTag());
        }

        public void DeleteTag(int id)
        {
            var tag = _tagRepository.GetById(id);
            if (tag == null)
            {
                throw new TagNotFoundException($"Tag with id {id} does not exist!");
            }
            _tagRepository.Delete(tag);
        }

        public void UpdateTag(UpdateTagDto updateTagDto)
        {
            var tag = _tagRepository.GetById(updateTagDto.Id);
            if (tag == null)
            {
                throw new TagNotFoundException($"Tag with id {updateTagDto.Id} does not exist!");
            }
            var tagExists = _tagRepository.GetTagByValue(updateTagDto.Value);
            if (tagExists != null)
            {
                throw new TagDataException("The tag already exists!");
            }
            tag.Value = updateTagDto.Value;
            _tagRepository.Update(tag);
        }
    }
}
