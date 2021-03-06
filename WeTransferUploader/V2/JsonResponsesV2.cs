﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeTransferUploader.V2
{
    public abstract class JsonResponseV2
    {
        [JsonProperty("success")]
        public bool? Success { get; set; }

        public string Message { get; set; }

        public string RequestUri { get; set; }
    }

    public class TokenResponseV2 : JsonResponseV2
    {
        [JsonProperty("token")]
        public string Token { get; set; }

    }

    public class TransferRequestResponseV2: JsonResponseV2
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("files")]
        public SingleFileTransferResponseData[] Files { get; set; }
    }

    public class SingleFileTransferResponseData:JsonResponseV2
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("multipart")]
        public FilePartResponseData ChunkData { get; set; }

        [JsonIgnore]
        public string FullPath { get; set; }
    }

    public class FilePartResponseData
    {
        [JsonProperty("part_numbers")]
        public int NumberOfParts { get; set; }

        [JsonProperty("chunk_size")]
        public int ChunkSize { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class FilePartUploadUrlResponse:JsonResponseV2
    {
        [JsonProperty("url")]
        public string Url { get; set; }
        public int PartNumber { get; set; }
    }

    public class SingleFileUploadCompletedResponse:JsonResponseV2
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("retries")]
        public int NumberOfRetries { get; set; }

        [JsonProperty("name")]
        public string FileName { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        [JsonProperty("chunk_size")]
        public int ChunkSize { get; set; }

    }

    public class TransferCompletedResponse: JsonResponseV2
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("message")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string DownloadUrl { get; set; }
    }

    #region "BoardApi specific responses"
    public class BoardCreatedResponse : JsonResponseV2
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("url")]
        public string BoardUrl { get; set; }
    }

    public class AddLinksResponse:JsonResponseV2
    {
        public AddLinkResponse[] LinksData { get; set; }
    }

    public class AddLinkResponse:JsonResponseV2
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("meta")]
        public LinkResponseMetaData MetaData{get;set;}
    }

    public class LinkResponseMetaData
    {
        [JsonProperty("title")]
        public string Title { get; set; }
    }

    public class BoardInfoResponse:JsonResponseV2
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("items")]
        public dynamic Items { get; set; }
    }

    #endregion
}
