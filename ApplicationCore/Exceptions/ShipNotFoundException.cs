using System;

namespace ApplicationCore.Exceptions;
public class ShipNotFoundException : Exception
{
    public ShipNotFoundException(int shipId) : base($"No ship found with id {shipId}")
    {
    }
}