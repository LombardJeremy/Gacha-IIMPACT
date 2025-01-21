using System;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;
using NaughtyAttributes;

public class TimePassed : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeText;


    [Button]
    private void GenerateNewTime()
    {
        _oldTime = new time(System.DateTime.Now.Day- Random.Range(2, 5), Random.Range(0, 23), Random.Range(10, 58));
        
        print( "ACTUAL TIME =  " + _newTime._days + "D"+  _newTime._hours+ "H" + _newTime._minutes+ "M"); 
        print( "OLD TIME =  " + _oldTime._days + "D"+  _oldTime._hours+ "H" + _oldTime._minutes+ "M"); 

        time differenceTime = ComapareTime();
        print( "differrence beetwen old and new = " + differenceTime._days + "D"+  differenceTime._hours+ "H" + differenceTime._minutes+ "M"); 
    }
    
    
    public struct time
    {
        public int _days;
        public int _hours;
        public int _minutes;

        public time(int dayPast, int hourPast, int minutesPast)
        {
            _days = dayPast;
            _hours = hourPast;
            _minutes = minutesPast;
        }
    }
    
    private time _newTime;
    private time _oldTime;
    


    private void GetAtualTime()
    {
        _newTime._days = System.DateTime.Now.Day;
        _newTime._hours = System.DateTime.Now.Hour;
        _newTime._minutes = System.DateTime.Now.Minute;
    }

    private void SetOldTime()
    {
        // METTRE L'ANCIEN TEMPS ENREGISTRER LORSQUE LE JOUEUR A QUITTER LE JEU
        
    }
    
    private void SaveTime()
    {
        // ENREGISTRER LE TEMPS LORSQUE LE JOUEUR QUITTE LE JEUX
        
    }

    private time ComapareTime()
    {
        // COMPARER LE NOUVEAU TEMPS ET L'ANCIEN ET RECUPERER LA DIFFERENCE ENTRE LES DEUX (RETOURNE UNE STRUCT TIME, le nombre de jour passé en tout, le nombre d'heure passé en tout, les minutes dans l'heure passés)

        int minutesPast = 0;
        int hourPast = 0;
        int daysPast = _newTime._days - _oldTime._days;
        
        if (_oldTime._days != _newTime._days)
        {
            hourPast = (24 * daysPast) - _oldTime._hours;
            hourPast += _newTime._hours;
        }
        else
        {
            hourPast = _oldTime._hours - _newTime._hours;
        }
        
        minutesPast = Math.Abs(_newTime._minutes - _oldTime._minutes);

        time differentTime = new time(daysPast, hourPast, minutesPast);
        return differentTime;
    }
    
    private void Update()
    {
        GetAtualTime();
        _timeText.text = _newTime._hours + ":" + _newTime._minutes;
    }
    
    private void OnEnable()
    {
        // RECUPERER LE TEMPS ET COMPARER AVEC L'ANCIEN
        GetAtualTime();
        ComapareTime();
    }

    private void OnDisable()
    {
        SaveTime();
    }
    
    
}
