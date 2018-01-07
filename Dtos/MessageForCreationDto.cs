using System;

namespace DatingApp.Api.Dtos
{
    public class MessageForCreationDto
    {
        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public DateTime MessagesSent { get; set; }
        public string Content { get; set; }
        public MessageForCreationDto()
        {
            MessagesSent = DateTime.Now;
        }
    }
}
