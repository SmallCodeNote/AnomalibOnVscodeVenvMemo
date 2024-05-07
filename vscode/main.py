import timm
from anomalib.data import MVTec
from anomalib.models import Patchcore
from anomalib.engine import Engine

if __name__ == '__main__':
    # Initialize the datamodule, model and engine
    datamodule = MVTec(category="bottle")
    engine = Engine()
    model = Patchcore()

    # Train and Test the model
    engine.fit(datamodule=datamodule, model=model, ckpt_path=None)
    engine.test(datamodule=datamodule, model=model, ckpt_path=None, verbose=True)

    # Assuming the datamodule, model and engine is initialized from the previous step,
    # a prediction via a checkpoint file can be performed as folows:
    predictions = engine.predict(datamodule=datamodule, model=model, ckpt_path=None, return_predictions=True)