namespace CQS
{

    public class FileStoreClient
    {
        public void ExecuteSave()
        {
            //input
            FileStoreStep1 store = new FileStoreStep1();
            store.Save(52, "Hello world");//throws exception as working directory is null, so this is pre condition we need to set
        }
    }
}
