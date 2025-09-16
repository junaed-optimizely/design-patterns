# Object Pool Pattern

This example demonstrates the **Object Pool** design pattern in C#. The Object Pool pattern is used to manage the reuse of objects that are expensive to create, by keeping a pool of available objects and reusing them as needed.

## Overview

- **ObjectPool<T>**: A generic object pool that manages a queue of reusable objects of type `T`.
- **Demo.Connection**: A sample class representing a resource (e.g., a database connection) that can be pooled.
- **Demo.Run()**: Demonstrates how to use the object pool to acquire and release objects.

## How It Works

1. The pool is initialized with a maximum size. It pre-creates that many objects and stores them in a queue.
2. When an object is needed, `Occupy()` is called:
   - If an object is available in the pool, it is dequeued and returned.
   - If the pool is empty, a new object is created.
3. When done, the object is returned to the pool using `Release()`.

## Example Usage

```csharp
var connectionPool = new ObjectPool<Demo.Connection>(3);
var conn = connectionPool.Occupy();
conn.Execute("SELECT * FROM Users");
connectionPool.Release(conn);
```

## Code Structure

- `ObjectPool<T>`
  - `Occupy()`: Gets an object from the pool or creates a new one if the pool is empty.
  - `Release(T obj)`: Returns an object to the pool.
- `Demo.Connection`
  - `Execute(string query)`: Simulates executing a query.
- `Demo.Run()`: Shows how to use the pool.

## When to Use
- When object creation is expensive (e.g., database connections, threads).
- When you need to limit the number of active objects.
- When objects can be safely reused.

## Limitations
- This simple implementation does not handle thread safety.
- No maximum pool size enforcement after initial creation.
- Objects are assumed to be stateless or reset before reuse.

---

**File:** [ObjectPool.cs](ObjectPool.cs)
