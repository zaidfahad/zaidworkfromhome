import { Component } from "@angular/core";
import {SpeechRecognition,SpeechRecognitionTranscription,SpeechRecognitionOptions} from 'nativescript-speech-recognition';
@Component({
  selector: "my-app",
  template: `
    <ActionBar title="My App" class="action-bar"></ActionBar>
    <StackLayout>
    <Button text="start" (tap)="triggerListening()">
    </Button>
    <Button text="stop" (tap)="stopListening()">
    </Button>
    
  `
})
export class AppComponent {
  options:SpeechRecognitionOptions;
  constructor(private speechobj:SpeechRecognition){
this.options = {
locale:'en-US',
onResult:(transcription:SpeechRecognitionTranscription) =>{
  console.log(`${transcription.text}`);
  console.log(`${transcription.finished}`);
}
}
  }
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
  // Your TypeScript logic goes here
}
