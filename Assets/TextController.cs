using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, free};
    private States myState;

	// Use this for initialization
	void Start () {
        myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
        if(myState == States.cell) {
            state_cell();
        } else if (myState == States.sheets_0) {
            state_sheets_0();
        } else if(myState == States.lock_0) {
            state_lock_0();
        } else if(myState == States.mirror) {
            state_mirror();
        } else if (myState == States.cell_mirror) {
            state_cell_mirror();
        } else if (myState == States.sheets_1) {
            state_sheets_1();
        } else if (myState == States.lock_1) {
            state_lock_1();
        } else if (myState == States.free) {
            state_free();
        }

	}
    void state_cell() {
        text.text = "You are in a prison cell and want to escape." +
                    "There are some dirty Sheets on the bed, a mirror on the wall " +
                    " and the door is locked from the outside.Press the number denoted to do the action.\n\n" +
                    "1. To View Sheets " +
                    "2. To View Mirror " +
                    "3. To View Lock";
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            myState = States.sheets_0;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            myState = States.mirror;
        } else if (Input.GetKeyDown(KeyCode.Alpha3)) {
            myState = States.lock_0;
        }
    }

    void state_sheets_0() {
        text.text = "You can't believe you sleep in these sheets. Surely it's time somebody changed them.\n\n " +
            "1. To return to roaming your cell.";
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            myState = States.cell;
        }
    }

    void state_sheets_1() {
        text.text = "Holding a mirror in your hands does not make the sheets look any better.\n\n " +
            "1. To return to roaming your cell.";
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            myState = States.cell_mirror;
        }
    }

    void state_lock_0() {
        text.text = "This is one of those button locks. You have no idea what the combination is. " +
            "You wish you could somehow see where the dirty fingerprints were, maybe that would help.\n\n" +
            "1. To return to roaming your cell.";
        if(Input.GetKeyDown(KeyCode.Alpha1)) {
            myState = States.cell;
        }
    }

    void state_lock_1() {
        text.text = "You carefully put the mirror through the bars and turn it over, so you can see the lock." +
            "You can just make out fingerprints around the buttons. You press the dirty buttons and hear a click.\n\n" +
            "1. To Open " +
            "2. To Keep on roaming in your cell.";
        if (Input.GetKeyDown(KeyCode.Alpha1)) { myState = States.free; }
        else if(Input.GetKeyDown(KeyCode.Alpha2)) { myState = States.cell_mirror; }
    }

    void state_mirror() {
        text.text = "The dirty mirror seems to be coming loose.\n\n" +
            "1. To take the mirror. " +
            "2. To return to the cell.";
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            myState = States.cell_mirror;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            myState = States.cell;
        }
    }

    void state_cell_mirror() {
        text.text = "You are still in your cell, and you STILL want to escape! There are " +
                    "some dirty sheets on the bed, a mark where the mirror was, " +
                    "and that pesky door is still there, and firmly locked!\n\n" +
                    "1. To view Sheets " +
                    "2. To view Lock";

        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            myState = States.sheets_1;
        } else if (Input.GetKeyDown(KeyCode.Alpha2)) {
            myState = States.lock_1;
        }
    }

    void state_free() {
        text.text = "You are out of your cell.\n\n" +
            "1. To play again";
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            myState = States.cell;
        }
            
    }

}
