using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class BulletCountController : MonoBehaviour
{
    [SerializeField] private Text _bulletCountText;

    [SerializeField] private Image bulletIcon;

    public Color UnfocusColor;
    public Color FocusColor;
    public Vector3 FocusScale = new Vector3(1f, 1f, 1f);
    public Vector3 UnfocusScale = new Vector3(0.75f, 0.75f, 0.75f);
    private float focusedX;
    private float unfocusedX;

    private void Awake() {
        focusedX = transform.position.x;
        unfocusedX = focusedX - (1f - UnfocusScale.x) * focusedX;
    }

    public void RefreshBulletCount(int bulletsLoaded, int bulletsMagazine) {
        _bulletCountText.text = $"{bulletsLoaded}/{bulletsMagazine}";
    }

    public void Unfocus() {
        transform.localScale = UnfocusScale;
        transform.position = new Vector3(unfocusedX, transform.position.y, transform.position.z); 
        _bulletCountText.color = UnfocusColor;
        bulletIcon.color = UnfocusColor;
    }

    public void Focus() {
        transform.localScale = FocusScale;
        transform.position = new Vector3(focusedX, transform.position.y, transform.position.z);
        _bulletCountText.color = FocusColor;
        bulletIcon.color = FocusColor;
    }
}
