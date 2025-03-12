using System;
using System.Collections.Generic;
using FinancialAccount.Patterns.Observer;

namespace FinancialAccounts.Models;

public class BankAccount : IObservable
{
    public int id { get; set; }
    public string name { get; set; }
    public decimal balance { get; set; }
    
    private List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver observer)
    {
        _observers. Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers(string message)
    {
        foreach (var ob in _observers)
        {
            ob.Update(message);
        }
    }

    public void UpdateBalance(decimal balance)
    {
        this.balance = balance;
        NotifyObservers($"Balance account id: {id} changes: {balance}");
    }

    public void UpdateName(string name)
    {
        this.name = name;
        NotifyObservers($"Name account id: {id} changes: {name}");
    }
    
    
}