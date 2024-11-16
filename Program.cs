using System;

class Program
{
    static void Main(string[] args)
    {
        ListaDoble listaDoble = new ListaDoble();
        listaDoble.Agregar(1);
        listaDoble.Agregar(2);
        listaDoble.Agregar(3);
        listaDoble.ImprimirAdelante();
        listaDoble.ImprimirAtras();
        listaDoble.Buscar(2);
        listaDoble.Modificar(2, 5);
        listaDoble.ImprimirAdelante();
        listaDoble.Eliminar(5);
        listaDoble.ImprimirAdelante();
    }
}

class Nodo
{
    public int dato;
    public Nodo siguiente;
    public Nodo anterior;

    public Nodo(int dato)
    {
        this.dato = dato;
        siguiente = null;
        anterior = null;
    }
}

class ListaDoble
{
    private Nodo cabeza;

    public ListaDoble()
    {
        cabeza = null;
    }

    public void Agregar(int dato)
    {
        Nodo nuevoNodo = new Nodo(dato);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.siguiente != null)
            {
                actual = actual.siguiente;
            }
            actual.siguiente = nuevoNodo;
            nuevoNodo.anterior = actual;
        }
    }

    public void Eliminar(int dato)
    {
        Nodo actual = cabeza;
        while (actual != null && actual.dato != dato)
        {
            actual = actual.siguiente;
        }
        if (actual == null)
        {
            Console.WriteLine("Elemento no encontrado.");
            return;
        }
        if (actual.anterior != null)
        {
            actual.anterior.siguiente = actual.siguiente;
        }
        else
        {
            cabeza = actual.siguiente;
        }
        if (actual.siguiente != null)
        {
            actual.siguiente.anterior = actual.anterior;
        }
    }

    public void Buscar(int dato)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.dato == dato)
            {
                Console.WriteLine("Elemento encontrado: " + dato);
                return;
            }
            actual = actual.siguiente;
        }
        Console.WriteLine("Elemento no encontrado.");
    }

    public void Modificar(int dato, int nuevoDato)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.dato == dato)
            {
                actual.dato = nuevoDato;
                Console.WriteLine("Elemento modificado.");
                return;
            }
            actual = actual.siguiente;
        }
        Console.WriteLine("Elemento no encontrado.");
    }

    public void ImprimirAdelante()
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            Console.Write(actual.dato + " ");
            actual = actual.siguiente;
        }
        Console.WriteLine();
    }

    public void ImprimirAtras()
    {
        if (cabeza == null) return;
        Nodo actual = cabeza;
        while (actual.siguiente != null)
        {
            actual = actual.siguiente;
        }
        while (actual != null)
        {
            Console.Write(actual.dato + " ");
            actual = actual.anterior;
        }
        Console.WriteLine();
    }
}

