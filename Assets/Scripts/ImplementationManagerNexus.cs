using UnityEngine;
using System.Collections;

public class ImplementationManagers
{
    public static UIManager UIManagement;
    public static CombatManager CombatManagement;
    public static CharacterManager CharacterManagement;
    public static PlayerAnimationHandler PlayerAnimationHandling;

    public static void InstantiateNewManagers()
    {
        UIManagement = new UIManager();
        CombatManagement = new CombatManager();
        //CharacterManagement = new CharacterManager();
        PlayerAnimationHandling = new PlayerAnimationHandler();
    }
}