import os
from anomalib import TaskType
from anomalib.data import Folder
from anomalib.models import Patchcore
from anomalib.engine import Engine
from anomalib.deploy.export import ExportType
from anomalib.data.utils import TestSplitMode, ValSplitMode

if __name__ == '__main__':

    model_path = R"R:\model1"
    if not os.path.exists(model_path):
        os.makedirs(model_path)

    datamodule = Folder(
        name="Type1",
        root=R"R:\train1",
        normal_dir="good",
        normal_split_ratio = 0.0, #0.2,
        mask_dir = "mask",
        abnormal_dir = "ng",

        task = TaskType.SEGMENTATION,

        test_split_mode = TestSplitMode.NONE,
        val_split_mode = ValSplitMode.FROM_TRAIN,
    )

    datamodule.setup()

    # Initialize the model and engine
    engine = Engine()
    model = Patchcore()

    # Train and Test the model
    engine.fit(datamodule=datamodule, model=model, ckpt_path=None)
    
    engine.export(model=model,export_type=ExportType.TORCH,export_root=model_path)
    engine.export(model=model,export_type=ExportType.ONNX,export_root=model_path)
    engine.export(model=model,export_type=ExportType.OPENVINO ,export_root=model_path)
    
    engine.test(datamodule=datamodule, model=model, ckpt_path=None, verbose=True)

    # Assuming the datamodule, model and engine is initialized from the previous step,
    # a prediction via a checkpoint file can be performed as folows:
    predictions = engine.predict(datamodule=datamodule, model=model, ckpt_path=None, return_predictions=True)
