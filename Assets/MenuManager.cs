using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public GameObject panel; // Main menu panel
    public GameObject panel1; // Waiting page panel
    public GameObject panel2; // 8-player panel
    public GameObject panel3; // 10-player panel
    public GameObject panel4; // 12-player panel

    // UI Elements for 8-player panel
    public TMP_Text roleText8;
    public Button nextRoleButton8;

    // UI Elements for 10-player panel
    public TMP_Text roleText10;
    public Button nextRoleButton10;

    // UI Elements for 12-player panel
    public TMP_Text roleText12;
    public Button nextRoleButton12;

    private List<string> eight_roles = new List<string>();
    private List<string> ten_roles = new List<string>();
    private List<string> twelve_roles = new List<string>();

    private System.Random random = new System.Random(); // For selecting random roles

    void Start()
    {
        // Populate roles (same as before)
        eight_roles = new List<string> { /* Add roles for 8-player */ };
        ten_roles = new List<string> { /* Add roles for 10-player */ };
        twelve_roles = new List<string> { /* Add roles for 12-player */ };

        // Assign roles for 8-player game
        eight_roles.Add("Godfather (Padrino)");
        eight_roles.Add("Simple Mafia");
        eight_roles.Add("Masked Mafia");
        eight_roles.Add("Detective");
        eight_roles.Add("Doctor");
        eight_roles.Add("Sniper ");
        eight_roles.Add("Citizen");
        eight_roles.Add("Citizen");

        // Assign roles for 10-player game
        ten_roles.Add("Godfather");
        ten_roles.Add("Simple Mafia");
        ten_roles.Add("Masked Mafia");
        ten_roles.Add("Detective");
        ten_roles.Add("Doctor");
        ten_roles.Add("Sniper ");
        ten_roles.Add("Mayor/Psychologist ");
        ten_roles.Add("Citizen");
        ten_roles.Add("Citizen");
        ten_roles.Add("Citizen");

        // Assign roles for 12-player game
        twelve_roles.Add("Godfather");
        twelve_roles.Add("Simple Mafia");
        twelve_roles.Add(" Masked Mafia");
        twelve_roles.Add("Mafia Assassin");
        twelve_roles.Add("Detective");
        twelve_roles.Add("Doctor");
        twelve_roles.Add("Sniper ");
        twelve_roles.Add("Mayor/Psychologist");
        twelve_roles.Add("Citizen");
        twelve_roles.Add("Citizen");
        twelve_roles.Add("Freemason");
        twelve_roles.Add("Special Role ");

        ShowMainMenu();

        // Assign onClick for each button to show the next role
        nextRoleButton8.onClick.AddListener(ShowRandomRoleForEight);
        nextRoleButton10.onClick.AddListener(ShowRandomRoleForTen);
        nextRoleButton12.onClick.AddListener(ShowRandomRoleForTwelve);
    }

    // Main menu and panel display functions remain the same
    public void ShowMainMenu()
    {
        panel.SetActive(true);
        panel1.SetActive(false);
        panel2.SetActive(false);
        panel3.SetActive(false);
        panel4.SetActive(false);

        roleText8.text = "Click To See Your Role";
        roleText10.text = "Click To See Your Role";
        roleText12.text = "Click To See Your Role";
    }

    public void ShowWaitingPage(List<string> roles, GameObject targetPanel)
    {
        panel.SetActive(false);
        panel1.SetActive(true);
        targetPanel.SetActive(false); // Hide panel for transition effect

        StartCoroutine(ShowAfterDelay(targetPanel, roles));
    }

    private IEnumerator ShowAfterDelay(GameObject targetPanel, List<string> roles)
    {
        yield return new WaitForSeconds(2.0f); // Wait for 2 seconds
        panel1.SetActive(false);
        targetPanel.SetActive(true);
        ResetRoles(roles); // Reset the roles list for a new session
    }

    public void ShowEightPage()
    {
        ShowWaitingPage(eight_roles, panel2);
    }

    public void ShowTenPage()
    {
        ShowWaitingPage(ten_roles, panel3);
    }

    public void ShowTwelvePage()
    {
        ShowWaitingPage(twelve_roles, panel4);
    }

    // Reset the role lists so all roles can be shown again when revisiting the page
    private void ResetRoles(List<string> roles)
    {
        //roles.Shuffle(); // Optional shuffle to randomize initial order
    }

    // Functions to display a random role for each page

    public void ShowRandomRoleForEight()
    {
        DisplayRandomRole(eight_roles, roleText8, nextRoleButton8);
    }

    public void ShowRandomRoleForTen()
    {
        DisplayRandomRole(ten_roles, roleText10, nextRoleButton10);
    }

    public void ShowRandomRoleForTwelve()
    {
        DisplayRandomRole(twelve_roles, roleText12, nextRoleButton12);
    }

    private void DisplayRandomRole(List<string> roles, TMP_Text roleText, Button button)
    {
        if (roles.Count > 0)
        {
            int index = random.Next(roles.Count);
            roleText.text = roles[index];
            roles.RemoveAt(index); // Remove role to prevent repeats
        }
        else
        {
            roleText.text = "All roles have been shown!";
            button.interactable = false; // Disable button when all roles are shown
        }
    }
}
