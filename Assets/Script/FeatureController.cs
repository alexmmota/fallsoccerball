using UnityEngine;
using System.Collections;

public class FeatureController{
	public enum Feature
	{
		normal,
		life1,
		life2,
		life3,
		death1,
		death2,
		surprise
	}

	public static FeatureController instance;
	private int countSurprise;
	private int rndSurprise;
	private int countToLife;
	private int rndToLife;
	private int countToLife2;
	private int rndToLife2;
	private int countToLife3;
	private int rndToLife3;
	private int countToDeath;
	private int rndToDeath;
	private int countToDeath2;
	private int rndToDeath2;
	private int countStart;
	private System.Random random;
	
	private FeatureController(){
		random = new System.Random ();
	}

	public static FeatureController Instance {
	get {
		if (instance == null) {
				instance = new FeatureController ();
			}
			return instance;
		}
	}

	private void setDefaultValues(){
		countSurprise = 0;
		rndSurprise = 0;
		countStart = 0;
		countToLife = 0;
		rndToLife = 0;
		countToLife2 = 0;
		rndToLife2 = 0;
		countToLife3 = 0;
		rndToLife3 = 0;
		countToDeath = 0;
		rndToDeath = 0;
		countToDeath2 = 0;
		rndToDeath2 = 0;
	}

	public Feature chooseFeature(){
		int iniLife1, iniLife2, iniLife3, fimLife1, fimLife2, fimLife3;
		if(InfoController.Instance.level <= 10){
			iniLife1 = 15;
			iniLife2 = 85;
			iniLife3 = 150;
			
			fimLife1 = 20;
			fimLife2 = 90;
			fimLife3 = 155;
		} else if (InfoController.Instance.level > 10 && InfoController.Instance.level <16) {
			iniLife1 = 30;
			iniLife2 = 170;
			iniLife3 = 300;
			
			fimLife1 = 40;
			fimLife2 = 180;
			fimLife3 = 310;
		}else {
			iniLife1 = 100;
			iniLife2 = 460;
			iniLife3 = 900000;
			
			fimLife1 = 150;
			fimLife2 = 500;
			fimLife3 = 900002;
		}

		if (countStart > 25) {
			if (countToLife == rndToLife) {
				rndToLife = random.Next (iniLife1, fimLife1);
					if (countToLife == 0)
							return Feature.life1;
					countToLife = 0;
					return Feature.life1;
			} else {
					countToLife += 1;
			}

			if (countToLife2 == rndToLife2) {
				rndToLife2 = random.Next (iniLife2, fimLife2);
					if (countToLife2 == 0)
							return Feature.life2;
					countToLife2 = 0;
					return Feature.life2;				
			} else {
					countToLife2 += 1;
			}

			if (countToLife3 == rndToLife3) {
				rndToLife3 = random.Next (iniLife3, fimLife3);
					if (countToLife3 == 0)
							return Feature.life3;
					countToLife3 = 0;
					return Feature.life3;
			} else {
					countToLife3 += 1;
			}

			if (countToDeath == rndToDeath) {
					rndToDeath = random.Next (6, 10);
					if (countToDeath == 0)
							return Feature.death1;
					countToDeath = 0;
					return Feature.death1;
			} else {
					countToDeath += 1;
			}

			if (countToDeath2 == rndToDeath2) {
					rndToDeath2 = random.Next (15, 20);
					if (countToDeath2 == 0)
							return Feature.death2;
					countToDeath2 = 0;
					return Feature.death2;
			} else {
					countToDeath2 += 1;
			}

			if (countSurprise == rndSurprise) {
				rndSurprise = random.Next (27, 60);
				if (countSurprise == 0)
					return Feature.surprise;
				countSurprise = 0;
				return Feature.surprise;
			} else {
				countSurprise += 1;
			}
		}
		countStart++;
		return Feature.normal;
	}

}
