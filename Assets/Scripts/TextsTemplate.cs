using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Text Object")]
public class TextsTemplate : ScriptableObject
{
    [TextArea(3, 15)]
    [Tooltip("Cadena que contiene el texto de la historia cuando se va a tomar una decision. (Si no tiene decisiones, este es vacío)")]
    public string mainText;

    [Space(20)]
    [Tooltip("Variable que contiene la cantidad de opciones posibles que se pueden elegir")]
    public int optionsAmount;

    [Space(20)]
    [Tooltip("Lista que contiene los textos de las respuestas posibles.")]
    public List<string> responses = new List<string>();

    [Space(20)]
    [Tooltip("Lista que contiene los indices de la seccion o decisiones (del scriptable object y no los index del arreglo).")]
    public int[] arrayReferences = new int[3];

    [Space(20)]
    [Tooltip("Booleano que indica si se van a borrar los botones luego de tomar una decision")]
    public bool quitButtons;
    [Tooltip("Booleano que indica si se van a cargar estas opciones luego de una decision o una sección de dialogo")]
    public bool chargeAnotherOptions;

    [Space(20)]
    [Tooltip("Lista que contiene los dialogos de la sección actual (Seccion = conjunto de dialogos entre decisiones)")]
    public List<string> dialogs = new List<string>();
    [Tooltip("Variable que representa el index del arreglo en texts controller al cual quiere dirigirse luego de terminar los dialogos de la sección actual.")]
    public int optionsIndex;

    [Space(20)]
    [Tooltip("Esta variable indica si esta es la última decisión o sección del juego")]
    public bool endGame;
}
