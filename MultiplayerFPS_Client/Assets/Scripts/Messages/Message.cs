using System;

[Serializable]
public class Message
{
    public MessageType Type { get; set; }
    public TextMessage TextMessage { get; set; }
}
