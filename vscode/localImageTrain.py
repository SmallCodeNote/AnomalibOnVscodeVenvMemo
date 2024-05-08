from anomalib.data import Folder
from anomalib.models import Patchcore
from anomalib.engine import Engine
from anomalib.deploy.export import ExportType

if __name__ == '__main__':

    ckpt_path = R"R:\model"
    onnx_path = R"R:\model"
    vino_path = R"R:\model"

    datamodule = Folder(
        name="Type1",
        root=R"R:\train",
        normal_dir="good",
        mask_dir="mask",
        abnormal_dir="ng",
        normal_split_ratio=0.2,
    )

    datamodule.setup()

    # Initialize the model and engine
    engine = Engine()
    model = Patchcore()

    # Train and Test the model
    engine.fit(datamodule=datamodule, model=model, ckpt_path=None)
    
    engine.export(model=model,export_type=ExportType.TORCH,export_root=ckpt_path)
    engine.export(model=model,export_type=ExportType.ONNX,export_root=onnx_path)
    engine.export(model=model,export_type=ExportType.OPENVINO ,export_root=vino_path)
    
    engine.test(datamodule=datamodule, model=model, ckpt_path=None, verbose=True)

    # Assuming the datamodule, model and engine is initialized from the previous step,
    # a prediction via a checkpoint file can be performed as folows:
    predictions = engine.predict(datamodule=datamodule, model=model, ckpt_path=None, return_predictions=True)
