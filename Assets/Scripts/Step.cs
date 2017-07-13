﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class Step {

	public string answer;
	public string instruction;
	public string correct_response;
	public string error_response;
	public Command[] commands;

	public void populate (JSONNode stepJSON)
	{
		this.answer = stepJSON ["answer"];
		this.instruction = stepJSON["instruction"];
		this.instruction = this.instruction.Replace ("\\n", "\n");
		this.instruction = this.instruction.Replace ("\\t", "    ");
		this.correct_response = stepJSON["correct_response"];
		this.correct_response = this.correct_response.Replace ("\\n", "\n");
		this.correct_response = this.correct_response.Replace ("\\t", "    ");
		this.error_response = stepJSON["error_response"];
		this.error_response = this.error_response.Replace ("\\n", "\n");
		this.error_response = this.error_response.Replace ("\\t", "    ");

		int count = stepJSON ["commands"].Count;
		this.commands = new Command[count];

		for(int c=0; c<count; c++){
			var commandJSON = stepJSON["commands"][c];
			Command command = new Command();
			command.populate (commandJSON);
			this.commands[c] = command;
		}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string PrintInstructions(){
		string ret = "<color=#62FF89>"+ instruction+"</color>\n";
//		string ret = "<color=#00000000>"+instruction+"</color>\n";
//		string ret = instruction + "\n";
		return ret;
	}

	public string CommandsString(){
		string ret = "";
		for (int i = 0; i < commands.Length; i++) {
			ret += commands [i].command_name + " " + commands [i].argument;
			ret += "          ";
		}
		return ret;
	}

}
