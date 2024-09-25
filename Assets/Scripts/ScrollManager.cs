using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scorePrefab;
    [SerializeField] private GameObject _container;
    
    private List<TextMeshProUGUI> _scoreList = new List<TextMeshProUGUI>();
    private TextMeshProUGUI _lastSelectedText;
    
    public void AddView(string score)
    {
        if (_lastSelectedText != null)
        {
            _lastSelectedText.color = Color.white;
        }

        var newScore = Instantiate(_scorePrefab, _container.transform, true);
        newScore.transform.localScale = Vector3.one;

        newScore.text = score;
        newScore.color = Color.green;
        newScore.transform.SetParent(_container.transform);
        _scoreList.Add(newScore);
        
        _lastSelectedText = newScore;
    }

    public void EmptyContainer()
    {
        for (int i = 0; i < _scoreList.Count; i++)
        {
            var score = _scoreList[i];
            Destroy(score.gameObject);
        }
        if(_scoreList!=null)
            _scoreList.Clear();
    }
}
