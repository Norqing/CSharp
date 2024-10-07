using System;

public class BadCashException : Exception
{
    public BadCashException() : base("检测到坏钞票！存款失败。") { }
}
