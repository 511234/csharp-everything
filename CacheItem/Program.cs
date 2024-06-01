using System;

using System.Collections.Generic;

// From Coursera

class CacheItem<T>

{

    public T Value { get; set; }

    public DateTime ExpirationTime { get; set; }


    public CacheItem(T value, TimeSpan expirationDuration)

    {

        Value = value;

        ExpirationTime = DateTime.Now.Add(expirationDuration);

    }


    public bool IsExpired()

    {

        return DateTime.Now > ExpirationTime;

    }

}


class GenericCache<T>

{

    private Dictionary<string, CacheItem<T>> cache = new Dictionary<string, CacheItem<T>>();


    public void AddItem(string key, T value, TimeSpan expirationDuration)

    {

        CacheItem<T> cacheItem = new CacheItem<T>(value, expirationDuration);

        cache[key] = cacheItem;

    }


    public T GetItem(string key)

    {

        if (cache.TryGetValue(key, out CacheItem<T> cacheItem))

        {

            if (cacheItem.IsExpired())

            {

                // Remove expired item from the cache

                cache.Remove(key);

                throw new InvalidOperationException("Attempted to retrieve an expired item from the cache.");

            }


            return cacheItem.Value;

        }


        throw new KeyNotFoundException($"Item with key '{key}' not found in the cache.");

    }


    public void Display()

    {

        Console.WriteLine("Current items in the cache:");

        foreach (var kvp in cache)

        {

            Console.WriteLine($"Key: {kvp.Key}, Expiration Time: {kvp.Value.ExpirationTime}, Value: {kvp.Value.Value}");

        }

    }

}


class Program

{

    static void Main()

    {

        // Example usage with integers

        GenericCache<int> intCache = new GenericCache<int>();

        intCache.AddItem("Number1", 42, TimeSpan.FromSeconds(5));

        intCache.Display();


        Console.WriteLine($"Retrieved item: {intCache.GetItem("Number1")}");

        intCache.Display();


        // Wait for the item to expire

        Console.WriteLine("Waiting for item to expire...");

        System.Threading.Thread.Sleep(6000);


        // Attempt to retrieve an expired item

        try

        {

            Console.WriteLine($"Retrieved item: {intCache.GetItem("Number1")}");

        }

        catch (Exception ex)

        {

            Console.WriteLine($"Error: {ex.Message}");

        }


        // Example usage with strings

        GenericCache<string> stringCache = new GenericCache<string>();

        stringCache.AddItem("Message1", "Hello, World!", TimeSpan.FromMinutes(1));

        stringCache.Display();


        Console.WriteLine($"Retrieved item: {stringCache.GetItem("Message1")}");

        stringCache.Display();

    }

}

