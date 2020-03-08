import { Component, OnInit } from '@angular/core';
import {SpeechRecognition,SpeechRecognitionTranscription,SpeechRecognitionOptions} from 'nativescript-speech-recognition';
import { android } from 'tns-core-modules/application/application';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  
  constructor(private speechobj:SpeechRecognition){
    this.options = {
    locale:'en-US',
    
    onResult:(transcription:SpeechRecognitionTranscription) =>{
      console.log(`${transcription.text}`);
      console.log(`${transcription.finished}`);
    }
    }
      }
  ngOnInit() {
    this.speechobj.requestPermission().then((granted: boolean) => {
      console.log("Granted? " + granted);
    });
    this.triggerListening(); 
  }
  options:SpeechRecognitionOptions;
  
  triggerListening(){
    this.speechobj.available().then(result=>{
      result?this.startListening():alert('Speech recognition');
    },error=>{
      console.log(error);
    }
    )
  }
  startListening(){
    this.speechobj.startListening(this.options).then(
      ()=>{
        console.log('Start Listening!')
    },error=>{
       console.error(error);
    }
    );
  }

  stopListening(){
    this.speechobj.stopListening().then(()=>{
console.log('Stopped');
    },error=>{
       console.error(error);     
    })
  }
}

