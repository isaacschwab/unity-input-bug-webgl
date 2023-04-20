import logo from './logo.svg';
import './App.css';

import React from "react";
import { Unity, useUnityContext } from "react-unity-webgl";

function App() {
  const [overlay, setOverlay] = React.useState(false);

  const { unityProvider, addEventListener, removeEventListener } = useUnityContext({
    loaderUrl: "build/TestBuild.loader.js",
    dataUrl: "build/TestBuild.data",
    frameworkUrl: "build/TestBuild.framework.js",
    codeUrl: "build/TestBuild.wasm",
  });

  const handleObjectClicked = React.useCallback(
		(objectName) => {
			console.log(`React Called from Unity: ${objectName}`);
		},
		[]
	);

  React.useEffect(() => {
		addEventListener('ObjectClicked', handleObjectClicked);
		
		return () => {
			removeEventListener('ObjectClicked', handleObjectClicked);
		};
	}, [
		addEventListener,
		removeEventListener,
	]);


  return (
    <div>
      <button style={{zIndex: 2, position: 'absolute', top: 0}}onClick={() => setOverlay(!overlay)}>Toggle Overlay</button>
      {overlay &&
        <div style={{zIndex: 1, position: 'absolute', height: '100%', width: '100%', top: 0, left: 0, backgroundColor: 'rgba(0, 0, 0, 0.5)'}}></div>
      }
      
      <Unity style={{zIndex: 0, width: '100vw', height: '100vh'}} unityProvider={unityProvider} />
    </div>
  )
}

export default App;
