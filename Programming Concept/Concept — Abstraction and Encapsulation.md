---
tags:
- Concept
date: 2024-11-24
---

# Abstraction and Encapsulation

Sure, let's break it down:

- **Abstraction** is like using a remote control. You press the "volume up" button to increase the volume. You don't need to know how the signal is sent, received, and processed inside the TV. You just need to know which button to press. This is abstraction - it's about simplifying things by only showing you what's necessary and hiding the complex details.

- **Encapsulation** is like a capsule (think of a pill). Inside the capsule, there are different ingredients mixed together, but from the outside, you can't see or access these ingredients directly. You can only swallow the pill as a whole. In programming, encapsulation is about bundling data (like variables) and behaviors (like methods) together into an object, and controlling access to that data.

```c#
// This is encapsulation
public class Television {
    private int volume;

    // This is abstraction
    public void IncreaseVolume()  {
        if(volume < 100)
            volume++;
    }

    // This is abstraction
    public void DecreaseVolume()  {
        if(volume > 0)
            volume--;
    }

    public int GetVolume() => return volume;
}

class Program {
    static void Main(string[] args) {
        Television tv = new Television();

        tv.IncreaseVolume(); // Using abstraction to increase volume
        tv.DecreaseVolume(); // Using abstraction to decrease volume

        Console.WriteLine(tv.GetVolume()); // Prints the current volume
    }
}
```

In this code, we have a `Television` class that encapsulates a `volume` variable. The `IncreaseVolume` and `DecreaseVolume` methods provide an abstract way to interact with the `volume` variable without knowing how it's implemented.

> without knowing how it's implemented

without knowing itu maksdunya external code yang nge-akses code ini
kan `Main` manggil `IncreaseVolume` atau `DecreaseVolume` tanpa tau gimana si `Television` ini ngurusin cara dan data yang dipake buat ngelakuin Increase sama Decrease tadi
yang punya knowledge cuma class `Television`

ini ngomongin antar class bukan ngomongin programmer-nya tau atau enggak

