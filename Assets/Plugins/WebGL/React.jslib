mergeInto(LibraryManager.library, {
  ObjectClicked: function (objectName) {
    window.dispatchReactUnityEvent("ObjectClicked", objectName);
  }
});