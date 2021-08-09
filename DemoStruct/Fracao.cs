using System;

public struct Fracao {
    private readonly int num;
    private readonly int den;
    public Fracao(int numerador, int denominador)
    {
        num = numerador;
        den = denominador;
    }
    public static Fracao operator +(Fracao a, Fracao b)
    {
        return new Fracao(a.num * b.den + b.num * a.den, a.den * b.den);
    }
    public int Denominador
    {
        get { return den; }
    }
    public int Numerador
    {
        get { return num; }
    }
}